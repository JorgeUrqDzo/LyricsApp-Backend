import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { SongModel } from '../models/Song';
import { ApiSuccess } from '../models/ResponseModel';
import { PagedResult } from '../models/PaginationModel';

@Injectable({
  providedIn: 'root',
})
export class SongsService {
  private _apiUrl = '';
  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient
  ) {
    this._apiUrl = this.baseUrl + 'api/songs';
  }

  get() {
    return this.http.get<ApiSuccess<PagedResult<SongModel>>>(this._apiUrl);
  }

  getById(id: string) {
    return this.http.get<ApiSuccess<SongModel>>(this._apiUrl + '/' + id);
  }

  create(data: SongModel) {
    return this.http.post<ApiSuccess<SongModel>>(this._apiUrl, data);
  }

  setFavorite(id: string, isFavorite: boolean) {
    return this.http.post<ApiSuccess<SongModel>>(this._apiUrl + `/${id}/favorite`, {
      id,
      isFavorite,
    });
  }

  update(id: string, data: SongModel) {
    return this.http.put(this._apiUrl + '/' + id, {
      id: data.id,
      title: data.title,
      lyric: data.lyric,
      genreId: data.genreId,
    });
  }

  delete(id: string) {
    return this.http.delete(this._apiUrl + '/' + id);
  }
}
