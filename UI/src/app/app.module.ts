import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuModule } from './features/nav-menu/nav-menu.module';
import { SearchPageComponent } from './pages/search-page/search-page.component';
import { AuthenticationModule } from './features/auth/auth.module';
import { MatToolbarModule} from '@angular/material/toolbar'; 
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { SearchResultsPageComponent } from './pages/search-results-page/search-results-page.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { AuthService } from './services/auth.service';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { EditProfilePageComponent } from './pages/edit-profile-page/edit-profile-page.component';
import { ViewProfilePageComponent } from './pages/view-profile-page/view-profile-page.component';
import { MyOrdersPageComponent } from './pages/my-orders-page/my-orders-page.component';
import { CarsPageComponent } from './pages/cars-page/cars-page.component';
import { CreateOrderPageComponent } from './pages/create-order-page/create-order-page.component';
import { MatProgressSpinner, MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { UsersListPageComponent } from './pages/users-list-page/users-list-page.component';
import { DeleteCarPageComponent } from './pages/delete-car-page/delete-car-page.component';
import { AddUserPageComponent } from './pages/add-user-page/add-user-page.component';
import { OrdersListPageComponent } from './pages/orders-list-page/orders-list-page.component';
import { AddCarPageComponent } from './pages/add-car-page/add-car-page.component';
import { DeleteOrderPageComponent } from './pages/delete-order-page/delete-order-page.component';
import { DeleteAdminPageComponent } from './pages/update-order-page/delete-admin-page.component';


@NgModule({
  declarations: [
    AppComponent,
    SearchPageComponent,
    SearchResultsPageComponent,
    ProfilePageComponent,
    ViewProfilePageComponent,
    MyOrdersPageComponent,
    // CarsPageComponent,
    // AdminPageComponent,
    // UsersListPageComponent,
    // DeleteCarPageComponent,
    // AddUserPageComponent,
    // DeleteUserPageComponent,
    // OrdersListPageComponent,
    // DeleteOrderPageComponent,
    // DeleteAdminPageComponent,
    // AddCarPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    AppRoutingModule,
    NavMenuModule,
    AuthenticationModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    provideAnimationsAsync(),
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
