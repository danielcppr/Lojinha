import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ControleClientesComponent } from './views/controle-clientes/controle-clientes.component';
import { HomeComponent } from './views/home/home.component';
import { NavigationComponent } from './views/navigation/navigation.component';

const routes: Routes = [
  { path: '',  redirectTo: '/home', pathMatch: 'full'},
  { path: 'home', component: HomeComponent },
  { path: 'controle-clientes', component: ControleClientesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
