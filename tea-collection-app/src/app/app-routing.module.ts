import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeaItemComponent } from './tea-item/tea-item.component';
import { TeaListComponent } from './tea-list/tea-list.component';

const routes: Routes = [
  { path: 'tea', component: TeaListComponent },
  { path: 'tea/:id', component: TeaItemComponent },
  { path: '**', redirectTo: 'tea', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
