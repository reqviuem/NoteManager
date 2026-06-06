import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { NoteService } from '../core/services/note.service';
import * as NoteActions from './note.actions';
import { catchError, map, mergeMap, of } from 'rxjs';

@Injectable()
export class NoteEffects {
  private actions$ = inject(Actions);
  private noteService = inject(NoteService);

  loadNotes$ = createEffect(() =>
    this.actions$.pipe(
      ofType(NoteActions.loadNotes),
      mergeMap(() =>
        this.noteService.getAll().pipe(
          map(notes => NoteActions.loadNotesSuccess({ notes })),
          catchError(error => of(NoteActions.loadNotesFailure({ error: error.message })))
        )
      )
    )
  );

  createNote$ = createEffect(() =>
    this.actions$.pipe(
      ofType(NoteActions.createNote),
      mergeMap(({ dto }) =>
        this.noteService.create(dto).pipe(
          map(note => NoteActions.createNoteSuccess({ note })),
          catchError(error => of(NoteActions.createNoteFailure({ error: error.message })))
        )
      )
    )
  );

  updateNote$ = createEffect(() =>
    this.actions$.pipe(
      ofType(NoteActions.updateNote),
      mergeMap(({ id, dto }) =>
        this.noteService.update(id, dto).pipe(
          map(note => NoteActions.updateNoteSuccess({ note })),
          catchError(error => of(NoteActions.updateNoteFailure({ error: error.message })))
        )
      )
    )
  );

  deleteNote$ = createEffect(() =>
    this.actions$.pipe(
      ofType(NoteActions.deleteNote),
      mergeMap(({ id }) =>
        this.noteService.delete(id).pipe(
          map(() => NoteActions.deleteNoteSuccess({ id })),
          catchError(error => of(NoteActions.deleteNoteFailure({ error: error.message })))
        )
      )
    )
  );
}
