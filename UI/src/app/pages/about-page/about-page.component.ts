import { Component, Inject } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector: 'about',
    templateUrl: './about-page.component.html',
    styleUrl: './about-page.component.css'
})
export class AboutPageComponent {

    constructor(private router: Router) {}

    goToCars() {
        this.router.navigate(['/cars']);
      }

    Register() {
        this.router.navigate(['/register']);
      }

    scrollToTop(): void {
        window.scrollTo({ top: 0, behavior: 'smooth' });
      }
}