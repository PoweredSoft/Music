import { Component } from '@angular/core';
import { IMenuItem } from 'src/models/IMenuItem';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'spa';

  menu: IMenuItem[] = [
    { title: 'Home', route: '/' },
    { title: 'Notes', route: '/notes' }
  ]
}
