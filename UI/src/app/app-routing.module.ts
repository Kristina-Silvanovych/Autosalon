import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutPageComponent } from './pages/about-page/about-page.component';
import { CarsPageComponent } from './pages/cars-page/cars-page.component';
import { ContactsPageComponent } from './pages/contacts-page/contacts-page.component';
import { SearchPageComponent } from './pages/search-page/search-page.component';
import { RegisterPageComponent } from './pages/register-page/register-page.component';
import { SigninPageComponent } from './pages/signin-page/signin-page.component';
import { SearchResultsPageComponent } from './pages/search-results-page/search-results-page.component';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { ViewProfilePageComponent } from './pages/view-profile-page/view-profile-page.component';
import { EditProfilePageComponent } from './pages/edit-profile-page/edit-profile-page.component';
import { MyOrdersPageComponent } from './pages/my-orders-page/my-orders-page.component';
import { CreateOrderPageComponent } from './pages/create-order-page/create-order-page.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { UsersListPageComponent } from './pages/users-list-page/users-list-page.component';
import { DeleteCarPageComponent } from './pages/delete-car-page/delete-car-page.component';
import { AddUserPageComponent } from './pages/add-user-page/add-user-page.component';
import { UpdateUserPageComponent } from './pages/update-user-page/update-user-page.component';
import { AddCarPageComponent } from './pages/add-car-page/add-car-page.component';
import { OrdersListPageComponent } from './pages/orders-list-page/orders-list-page.component';

const routes: Routes = [
    {
        path: 'cars',
        component: CarsPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'about',
        component: AboutPageComponent,        
        pathMatch: 'full',
    },
    {
        path: 'contacts',
        component: ContactsPageComponent,
        pathMatch: 'full',
    },
    {
        path: 'register',
        component: RegisterPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'signin',
        component: SigninPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'searchresults',
        component: SearchResultsPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'profile',
        component: ProfilePageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'view-profile',
        component: ViewProfilePageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'edit-profile',
        component: EditProfilePageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'edit-user/:id',
        component: EditProfilePageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'my-orders',
        component: MyOrdersPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'create-orders',
        component: CreateOrderPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'admin',
        component: AdminPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'usersList',
        component: UsersListPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'addUser',
        component: AddUserPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'addCar',
        component: AddCarPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'carsList',
        component: CarsPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'ordersList',
        component: OrdersListPageComponent,
        pathMatch: 'full',        
    },
    {
        path: 'editAdmin',
        component: UpdateUserPageComponent,
        pathMatch: 'full',        
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
