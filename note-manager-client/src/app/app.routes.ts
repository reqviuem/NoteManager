import { Routes } from '@angular/router';
import { NoteListComponent } from './features/notes/note-list/note-list';
import { NoteFormComponent } from './features/notes/note-form/note-form';

export const routes: Routes = [
  { path: '', redirectTo: 'notes', pathMatch: 'full' },
  { path: 'notes', component: NoteListComponent },
  { path: 'notes/new', component: NoteFormComponent },
  { path: 'notes/:id/edit', component: NoteFormComponent }
];
