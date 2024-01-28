import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { PaginationComponent } from 'src/app/components/pagination/pagination.component';
import { PaginationModel } from 'src/app/models/PaginationModel';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { SongFormComponent } from './song-form/song-form.component';

@Component({
  selector: 'app-songs',
  standalone: true,
  imports: [CommonModule, PaginationComponent],
  templateUrl: './songs.component.html',
  styleUrl: './songs.component.css',
})
export class SongsComponent {
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

  newSong() {
    this.dialog.showComponent(SongFormComponent, {
      width: '500px',
      disableClose: true,
    });
  }
}
