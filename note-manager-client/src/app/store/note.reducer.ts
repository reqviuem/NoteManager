import { createReducer, on } from '@ngrx/store';
import { Note } from '../core/models/note.model';
import * as NoteActions from './note.actions';

export interface NoteState {
  notes: Note[];
  loading: boolean;
  error: string | null;
}

export const initialState: NoteState = {
  notes: [],
  loading: false,
  error: null
};

export const noteReducer = createReducer(
  initialState,

  on(NoteActions.loadNotes, state => ({ ...state, loading: true })),
  on(NoteActions.loadNotesSuccess, (state, { notes }) => ({ ...state, notes, loading: false })),
  on(NoteActions.loadNotesFailure, (state, { error }) => ({ ...state, error, loading: false })),

  on(NoteActions.createNoteSuccess, (state, { note }) => ({
    ...state, notes: [...state.notes, note]
  })),

  on(NoteActions.updateNoteSuccess, (state, { note }) => ({
    ...state,
    notes: state.notes.map(n => n.id === note.id ? note : n)
  })),

  on(NoteActions.deleteNoteSuccess, (state, { id }) => ({
    ...state,
    notes: state.notes.filter(n => n.id !== id)
  }))
);
