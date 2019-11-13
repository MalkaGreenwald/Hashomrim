import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { VisitHashomrimPage } from './visit-hashomrim.page';

const routes: Routes = [
  {
    path: '',
    component: VisitHashomrimPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [VisitHashomrimPage]
})
export class VisitHashomrimPageModule {}
