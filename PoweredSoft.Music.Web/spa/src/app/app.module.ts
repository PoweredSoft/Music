import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotePageComponent } from 'src/pages/note/note-page.component';
import { HomePageComponent } from 'src/pages/home/home-page.component';
import { NoteService } from 'src/services/note.service';
import { NoteBadgeComponent } from 'src/components/note-badge/note-badge.component';
import { NoteComponent } from 'src/components/note/note.component';
import { NoteDetailPageComponent } from 'src/pages/note-detail/note-detail-page.component';
import { NoteIntervalService } from 'src/services/note-interval.service';
import { ChordService } from 'src/services/chord.service';
import { NotesBadgeSetComponent } from 'src/components/notes-badge-set/notes-badge-set.component';
import { ReverseChordPageComponent } from 'src/pages/reverse-chord/reverse-chord-page.component';
import { StringInstrumentComponent } from 'src/components/string-instrument/string-instrument.component';
import { GuitarComponent } from 'src/components/guitar/guitar.component';
import { GuitarService } from 'src/services/guitar.service';


const components = [NoteComponent, NoteBadgeComponent, NotesBadgeSetComponent, StringInstrumentComponent, GuitarComponent];
const pages = [HomePageComponent, NotePageComponent, NoteDetailPageComponent, ReverseChordPageComponent];
const services = [NoteService, NoteIntervalService, ChordService, GuitarService];

@NgModule({
  declarations: [
    AppComponent, components, pages
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [services],
  bootstrap: [AppComponent]
})
export class AppModule { }
