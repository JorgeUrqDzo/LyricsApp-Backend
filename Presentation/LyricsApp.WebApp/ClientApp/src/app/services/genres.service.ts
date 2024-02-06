import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ApiSuccess } from '../models/ResponseModel';
import { GenreModel } from '../models/Genre';

@Injectable({
  providedIn: 'root',
})
export class GenresService {
  private _apiUrl = '';
  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient
  ) {
    this._apiUrl = this.baseUrl + 'api/genres';
  }

  getGenres() {
    return this.http.get<ApiSuccess<GenreModel[]>>(this._apiUrl);
  }

  getGenreById(id: string) {
    return this.http.get<ApiSuccess<GenreModel>>(this._apiUrl + '/' + id);
  }

  createGenre(data: GenreModel) {
    return this.http.post<ApiSuccess<GenreModel>>(this._apiUrl, data);
  }

  updateGenre(id: string, data: GenreModel) {
    return this.http.put(this._apiUrl + '/' + id, {
      genreId: data.id,
      name: data.name,
    });
  }

  deleteGenre(id: string) {
    return this.http.delete(this._apiUrl + '/' + id, {
      body: {
        genreId: id,
      },
    });
  }
}
