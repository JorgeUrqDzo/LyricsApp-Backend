import { Component } from '@angular/core';
import { PaginationComponent } from 'src/app/components/pagination/pagination.component';
import { PaginationModel } from 'src/app/models/PaginationModel';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { PlaylistFormComponent } from './playlist-form/playlist-form.component';

@Component({
  selector: 'app-playlists',
  standalone: true,
  imports: [PaginationComponent],
  templateUrl: './playlists.component.html',
  styleUrl: './playlists.component.css',
})
export class PlaylistsComponent {
  pagination: PaginationModel = {
    currentPage: 1,
    pages: 4,
    pageSize: 100,
    totalRecords: 400,
  };

  constructor(private dialog: AppDialogService) {}

  changePageEvent($event: number) {
    console.log('page change:', $event);
  }

  newPlaylist() {
    this.dialog.showComponent(PlaylistFormComponent, {
      width: '380px',
      disableClose: true,
    });
  }
}
