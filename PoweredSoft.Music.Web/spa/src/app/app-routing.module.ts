import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotePageComponent } from 'src/pages/note/note-page.component';
import { HomePageComponent } from 'src/pages/home/home-page.component';
import { NoteDetailPageComponent } from 'src/pages/note-detail/note-detail-page.component';
import { ReverseChordPageComponent } from 'src/pages/reverse-chord/reverse-chord-page.component';
import { ChordPageComponent } from 'src/pages/chord/chord-page.component';
import { TestPageComponent } from 'src/pages/test/test.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'notes', component: NotePageComponent },
  { path: 'note/:note', component: NoteDetailPageComponent },
  { path: 'reverse-chord', component: ReverseChordPageComponent },
  { path: 'chords', component: ChordPageComponent },
  { path: 'test', component: TestPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
