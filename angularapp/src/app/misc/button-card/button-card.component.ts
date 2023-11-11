import { Component, HostListener, Input } from '@angular/core';

@Component({
  selector: 'app-button-card',
  templateUrl: './button-card.component.html',
  styleUrls: ['./button-card.component.css']
})
export class ButtonCardComponent {
  @Input() imgpath: string = "";
  @Input() text: string = "";


  constructor() { }
}
