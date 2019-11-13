import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { FreindlyMeetingPage } from './freindly-meeting.page';

const routes: Routes = [
  {
    path: '',
    component: FreindlyMeetingPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [FreindlyMeetingPage]
})
export class FreindlyMeetingPageModule {}
