import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SongsComponent } from './features/songs/songs.component';
import { PlaylistsComponent } from './features/playlists/playlists.component';
import { GenresComponent } from './features/genres/genres.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'songs', component: SongsComponent },
  { path: 'playlists', component: PlaylistsComponent },
  { path: 'genres', component: GenresComponent },
];

@NgModule({
  imports: [BrowserModule, RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutesModule {}
