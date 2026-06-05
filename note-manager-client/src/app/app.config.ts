import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, HttpClient } from '@angular/common/http';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideTranslateService, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { routes } from './app.routes';
import { noteReducer } from './store/note.reducer';
import { NoteEffects } from './store/note.effects';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    provideStore({ notes: noteReducer }),
    provideEffects([NoteEffects]),
    provideTranslateService({
      loader: {
        provide: TranslateLoader,
        useClass: TranslateHttpLoader
      },
      fallbackLang: 'en'
    })
  ]
};
