import { Component, OnInit, inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TranslatePipe } from '../../../core/pipes/translate.pipe';
import { createNote, updateNote, createNoteSuccess, updateNoteSuccess } from '../../../store/note.actions';
import { selectAllNotes, selectError } from '../../../store/note.selectors';
import { take, filter } from 'rxjs';
import { Actions, ofType } from '@ngrx/effects';
import { Note } from '../../../core/models/note.model';

@Component({
  selector: 'app-note-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, TranslatePipe],
  templateUrl: './note-form.html',
  styleUrl: './note-form.scss'
})
export class NoteFormComponent implements OnInit {
  private store = inject(Store);
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private fb = inject(FormBuilder);
  private actions$ = inject(Actions);

  form: FormGroup = this.fb.group({
    title: ['', Validators.required],
    content: ['', Validators.required]
  });

  isEditMode = false;
  noteId: string | null = null;
  error$ = this.store.select(selectError);

  ngOnInit() {
    const paramId = this.route.snapshot.params['id'];
    this.noteId = paramId ? paramId : null;
    this.isEditMode = !!this.noteId;

    if (this.isEditMode) {
      this.store.select(selectAllNotes).pipe(take(1)).subscribe(notes => {
        const note = notes.find((n: Note) => n.id === this.noteId);
        if (note) {
          this.form.patchValue({ title: note.title, content: note.content });
        }
      });
    }

    // navigate away only on success
    this.actions$.pipe(
      ofType(createNoteSuccess, updateNoteSuccess),
      take(1)
    ).subscribe(() => this.router.navigate(['/notes']));
  }

  onSubmit() {
    if (this.form.invalid) return;

    const dto = this.form.value;

    if (this.isEditMode && this.noteId) {
      this.store.dispatch(updateNote({ id: this.noteId, dto }));
    } else {
      this.store.dispatch(createNote({ dto }));
    }
  }

  onCancel() {
    this.router.navigate(['/notes']);
  }
}
