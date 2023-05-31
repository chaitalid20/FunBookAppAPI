import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent,
    children:[
      { path:'login', loadChildren:() => import('./components/login/login.module')
      .then(m =>m.LoginModule)},
      { path:'dashboard', loadChildren:() => import('./components/dashboard/dashboard.module')
      .then(m =>m.DashboardModule)},
      //canActivate:[authGuard]}
    ]
  }
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
