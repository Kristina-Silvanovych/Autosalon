import { NgModule } from "@angular/core";
import { AboutPageComponent } from "./about-page.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

@NgModule({
    imports: [
        CommonModule,
        RouterModule
    ],
    declarations: [
       AboutPageComponent
    ],
})
export class AboutPageModule { }