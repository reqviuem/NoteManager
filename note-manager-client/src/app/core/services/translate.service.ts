import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class TranslateService {
  private translations: Record<string, string> = {};
  currentLang = signal<string>('en');

  constructor(private http: HttpClient) {
    this.loadLanguage('en');
  }

  loadLanguage(lang: string) {
    this.http.get<Record<string, string>>(`/assets/i18n/${lang}.json`).subscribe(t => {
      this.translations = t;
      this.currentLang.set(lang);
    });
  }

  translate(key: string): string {
    return this.translations[key] || key;
  }
}
