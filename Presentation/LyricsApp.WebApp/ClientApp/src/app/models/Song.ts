import { GenreModel } from "./Genre";

export interface SongModel {
  id?: string | null;
  title?: string | null | undefined;
  lyric?: string | null;
  ownerId?: string | null;
  genreId?: string | null;
  genre?: GenreModel | null;
  isFavorite?: boolean | null;
}
