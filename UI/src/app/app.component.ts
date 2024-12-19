import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'autosalon';

  constructor(public authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    if (this.authService.isLoggedIn()) {
      if (this.authService.isAdmin()) {
        this.router.navigate(['/admin']); 
      } else {
        this.router.navigate(['/profile']); 
      }
    }
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/signin']);
  }

  goToProfile(): void {
    this.router.navigate(['/profile']);
  }

  // ngOnInit(): void {
  //   this.authService.user$.subscribe((user) => {
  //     this.userName = user;
  //     this.isLoggedIn = !!user;
  //   });
  // }
  
  // goToProfile() {
  //   this.router.navigate(['/profile']);
  // }

  // logout() {
  //   this.authService.logout();
  //   this.router.navigate(['/signin']);
  // }
  
}
