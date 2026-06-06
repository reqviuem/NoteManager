import { Component, OnInit, inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TranslatePipe } from '../../../core/pipes/translate.pipe';
import { createNote, updateNote } from '../../../store/note.actions';
import { selectAllNotes } from '../../../store/note.selectors';
import { take } from 'rxjs';

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

  form: FormGroup = this.fb.group({
    title: ['', [Validators.required, Validators.minLength(1)]],
    content: ['', [Validators.required, Validators.minLength(1)]]
  });

  isEditMode = false;
  noteId: number | null = null;

  ngOnInit() {
    this.noteId = this.route.snapshot.params['id'] ? +this.route.snapshot.params['id'] : null;
    this.isEditMode = !!this.noteId;

    if (this.isEditMode) {
      this.store.select(selectAllNotes).pipe(take(1)).subscribe(notes => {
        const note = notes.find(n => n.id === this.noteId);
        if (note) {
          this.form.patchValue({ title: note.title, content: note.content });
        }
      });
    }
  }

  onSubmit() {
    if (this.form.invalid) return;
    const dto = this.form.value;

    if (this.isEditMode && this.noteId) {
      this.store.dispatch(updateNote({ id: this.noteId, dto }));
    } else {
      this.store.dispatch(createNote({ dto }));
    }

    this.router.navigate(['/notes']);
  }

  onCancel() {
    this.router.navigate(['/notes']);
  }
}
