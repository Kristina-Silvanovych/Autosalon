import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isLoggedInStatus = false;

  login(user: any): void {
    this.isLoggedInStatus = true;
    localStorage.setItem('user', JSON.stringify(user));
  }

  logout(): void {
    this.isLoggedInStatus = false;
    localStorage.removeItem('user');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('user');
  }

  getUser(): any {
    return JSON.parse(localStorage.getItem('user')!);
  }

  isAdmin(): boolean {
    const user = this.getUser();
    return user ? user.isAdmin : false;
  }
  

  // private userKey = 'loggedUser';

  // loginUser(user: { email: string, password: string }) {
  //   localStorage.setItem(this.userKey, JSON.stringify(user));
  // }

  // isLoggedIn(): boolean {
  //   return localStorage.getItem(this.userKey) !== null;
  // }

  // getUser(): { email: string, password: string } | null {
  //   const user = localStorage.getItem(this.userKey);
  //   return user ? JSON.parse(user) : null;
  // }

  // logout() {
  //   localStorage.removeItem(this.userKey);
  // }
  // private userSubject = new BehaviorSubject<string | null>(this.getUserFromLocalStorage());
  // public user$ = this.userSubject.asObservable();

  // constructor() {}

  // login(username: string): void {
  //   this.userSubject.next(username);
  //   localStorage.setItem('loggedUser', username);
  // }

  // logout(): void {
  //   this.userSubject.next(null);
  //   localStorage.removeItem('loggedUser');
  // }

  // private getUserFromLocalStorage(): string | null {
  //   return localStorage.getItem('loggedUser');
  // }
}
