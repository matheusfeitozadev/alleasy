import { CategoriaComponent } from './Components/categoria/categoria.component';
import { ProdutoComponent } from './Components/produto/produto.component';
import { HomeComponent } from './Components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { 
    path : 'home', 
    component: HomeComponent
  },
  { 
    path : 'categoria', 
    component: CategoriaComponent
  },
  { 
    path : 'produto', 
    component: ProdutoComponent
  },
  { path: '',   redirectTo: '/home', pathMatch: 'full' },
  { path: '**',   redirectTo: '/home', pathMatch: 'full' }
];

/*
const routes: Routes = [
  { 
    path : '', 
    component: HomeComponent,
    children : [
      { path : 'home', component: HomeComponent },
      { path : 'produto', component: ProdutoComponent },
      { path : 'categoria', component: CategoriaComponent }
    ]
  }
];
*/

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
