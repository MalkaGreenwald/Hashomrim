import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', loadChildren: './Pages/home/home.module#HomePageModule' },
  { path: 'event', loadChildren: './Pages/event/event.module#EventPageModule' },
  { path: 'register', loadChildren: './Pages/register/register.module#RegisterPageModule' },
  { path: 'event-details', loadChildren: './Pages/event-details/event-details.module#EventDetailsPageModule' },
  { path: 'menu', loadChildren: './Pages/menu/menu.module#MenuPageModule' },
 
  // { path: 'definition', loadChildren: './Pages/definition/definition.module#DefinitionPageModule' }, 
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
