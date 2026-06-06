import {createAction, props} from '@ngrx/store';
import {Note, CreateNoteDto} from '../core/models/note.model';

export const loadNotes = createAction('[Notes] Load Notes');
export const loadNotesSuccess = createAction('[Notes] Load Notes Success', props<{ notes: Note[] }>());
export const loadNotesFailure = createAction('[Notes] Load Notes Failure', props<{ error: string }>());

export const createNote = createAction('[Notes] Create Note', props<{ dto: CreateNoteDto }>());
export const createNoteSuccess = createAction('[Notes] Create Note Success', props<{ note: Note }>());
export const createNoteFailure = createAction('[Notes] Create Note Failure', props<{ error: string }>());

export const updateNote = createAction('[Notes] Update Note', props<{ id: string; dto: CreateNoteDto }>());

export const updateNoteSuccess = createAction('[Notes] Update Note Success', props<{ note: Note }>());

export const updateNoteFailure = createAction('[Notes] Update Note Failure', props<{ error: string }>());

export const deleteNote = createAction('[Notes] Delete Note', props<{ id: string }>());

export const deleteNoteSuccess = createAction('[Notes] Delete Note Success', props<{ id: string }>());
export const deleteNoteFailure = createAction('[Notes] Delete Note Failure', props<{ error: string }>());
