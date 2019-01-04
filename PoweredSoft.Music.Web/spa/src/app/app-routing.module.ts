import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotePageComponent } from 'src/pages/note/note-page.component';
import { HomePageComponent } from 'src/pages/home/home-page.component';
import { NoteDetailPageComponent } from 'src/pages/note-detail/note-detail-page.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'notes', component: NotePageComponent },
  { path: 'note/:note', component: NoteDetailPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
