import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardComponent } from './card/card.component';
import { CreateCardComponent } from './create-card/create-card.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DeckComponent } from './deck/deck.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  // { path: '', component: LoginComponent },
  { path: '', component: DashboardComponent },
  { path: 'deck', component: DeckComponent },
  { path: 'create-card', component: CreateCardComponent },
  { path: 'card', component: CardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
