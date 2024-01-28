import { NgClass } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PaginationModel } from 'src/app/models/PaginationModel';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [NgClass],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css',
})
export class PaginationComponent implements OnInit {
  @Input({ required: true }) data?: PaginationModel;
  @Output() changePage = new EventEmitter<number>();

  disablePrevPage: Record<string, boolean> = {};
  disableNextPage: Record<string, boolean> = {};

  ngOnInit(): void {
    this.setDisableClasses();
  }

  changePageEvent(page: number) {
    if (this.data) {
      this.data.currentPage = page;
      this.setDisableClasses();
      this.changePage.emit(page);
    }
  }

  nextPage() {
    if (this.data) {
      const page = this.data.currentPage + 1;
      if (page <= this.data.pages) {
        this.changePageEvent(page);
      }
    }
  }

  prevPage() {
    if (this.data) {
      const page = this.data.currentPage - 1;
      if (page >= 1) {
        this.changePageEvent(page);
      }
    }
  }

  setDisableClasses() {
    if (this.data) {
      this.disablePrevPage = {
        disabled: this.data.currentPage == 1,
      };

      this.disableNextPage = {
        disabled: this.data.currentPage == this.data.pages,
      };
    }
  }
}
