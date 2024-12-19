import { Component, HostListener, Inject } from '@angular/core';
// import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'auth-button',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthButtonComponent {
  menuOpen = false;

  toggleMenu() {
    this.menuOpen = !this.menuOpen;
  }

  closeMenu() {
    this.menuOpen = false;
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    const targetElement = event.target as HTMLElement;

    if (this.menuOpen && !targetElement.closest('.auth-button') && !targetElement.closest('.menu-toolbar')) {
      this.menuOpen = false;
    }
  }
}

