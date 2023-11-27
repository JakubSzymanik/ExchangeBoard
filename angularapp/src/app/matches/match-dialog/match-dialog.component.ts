import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Item } from '../../_models/item';
import { MatchDialogData } from '../../_models/match-dialog-data';

@Component({
  selector: 'app-match-dialog',
  templateUrl: './match-dialog.component.html',
  styleUrls: ['./match-dialog.component.css']
})
export class MatchDialogComponent {
  imgAUrl: string = "";
  imgBUrl: string = "";

  constructor(
    private dialogRef: MatDialogRef<MatchDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: MatchDialogData) {
    this.imgAUrl = data.itemA.photos![0].url;
    this.imgBUrl = data.itemB.photos![0].url;
  }

  close() {
    this.dialogRef.close(false);
  }

  matches() {
    this.dialogRef.close(true);
  }
}
