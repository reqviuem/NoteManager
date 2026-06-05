import { createFeatureSelector, createSelector } from '@ngrx/store';
import { NoteState } from './note.reducer';

export const selectNoteState = createFeatureSelector<NoteState>('notes');

export const selectAllNotes = createSelector(selectNoteState, state => state.notes);
export const selectLoading = createSelector(selectNoteState, state => state.loading);
export const selectError = createSelector(selectNoteState, state => state.error);
