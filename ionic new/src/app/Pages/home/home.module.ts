import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { Keyboard } from '@ionic-native/keyboard/ngx';
import { HomePage } from './home.page';
import { MenuPage } from '../menu/menu.page';
const routes: Routes = [
  {
    path: '',
    component: MenuPage,
    }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild([
      {
        path: '',
        component: HomePage
      }
    ])
  ],
  providers:[Keyboard],
  declarations: [HomePage]
})
export class HomePageModule {}
