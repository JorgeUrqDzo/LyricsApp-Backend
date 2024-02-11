import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { SongModel } from 'src/app/models/Song';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-song-view',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './song-view.component.html',
  styleUrl: './song-view.component.css',
})
export class SongViewComponent {
  song: SongModel = {};
  private _id = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dialog: AppDialogService,
    private _songsService: SongsService
  ) {
    this._id = this.route.snapshot.params['id'];
    if (this._id.length != 36) {
      this.dialog.show('Error', 'Invalid page params').subscribe((res) => {
        this.router.navigate(['/songs/']);
      });
      return;
    }
    this.loadSong(this._id);
  }

  loadSong(id: string) {
    this._songsService.getById(id).subscribe({
      next: (data) => {
        if (data.success) {
          this.song = data.model;
        }

        this.dialog.loadingHide();
      },
      error: (err) => {
        console.log('err :>> ', err);
        this.dialog.loadingHide();
        this.dialog.show('Error', err.error.message).subscribe((res) => {
          this.router.navigate(['/songs/']);
        });
      },
    });
  }
}
