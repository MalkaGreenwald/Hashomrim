import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { EventPage } from './event.page';

// const routes: Routes = [
//   {
//     path: '',
//     component: EventPage
//   }
// ];

const routes: Routes = [
  {
    path: '',
    component: EventPage,
    children:[
      {
      path: 'main',
       loadChildren: '../main/main.module#MainPageModule'
       }, { path: 'event-details', loadChildren: '../event-details/event-details.module#EventDetailsPageModule' }

    ]
  }
];
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [EventPage]
})
export class EventPageModule {}
