import { Component, OnInit, inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TranslateService } from '../../../core/services/translate.service';
import { TranslatePipe } from '../../../core/pipes/translate.pipe';
import { selectAllNotes, selectLoading } from '../../../store/note.selectors';
import { loadNotes, deleteNote } from '../../../store/note.actions';
import { Observable } from 'rxjs';
import { Note } from '../../../core/models/note.model';

@Component({
  selector: 'app-note-list',
  standalone: true,
  imports: [CommonModule, RouterModule, TranslatePipe],
  templateUrl: './note-list.html',
  styleUrl: './note-list.scss'
})
export class NoteListComponent implements OnInit {
  private store = inject(Store);
  translateService = inject(TranslateService);

  notes$: Observable<Note[]> = this.store.select(selectAllNotes);
  loading$: Observable<boolean> = this.store.select(selectLoading);

  languages = [
    { code: 'en', label: 'English' },
    { code: 'es', label: 'Español' },
    { code: 'ru', label: 'Русский' }
  ];

  ngOnInit() {
    this.store.dispatch(loadNotes());
  }

  onDelete(id: number) {
    this.store.dispatch(deleteNote({ id }));
  }

  switchLanguage(lang: string) {
    this.translateService.loadLanguage(lang);
  }
}
