import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Note, CreateNoteDto } from '../models/note.model';

@Injectable({
  providedIn: 'root'
})
export class NoteService {
  private readonly apiUrl = 'http://localhost:5159/notes';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Note[]> {
    return this.http.get<Note[]>(this.apiUrl);
  }

  getById(id: string): Observable<Note> {
    return this.http.get<Note>(`${this.apiUrl}/${id}`);
  }

  create(dto: CreateNoteDto): Observable<Note> {
    return this.http.post<Note>(this.apiUrl, dto);
  }

  update(id: string, dto: CreateNoteDto): Observable<Note> {
    return this.http.put<Note>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: string): Observable<string> {
    return this.http.delete<string>(`${this.apiUrl}/${id}`);
  }
}
