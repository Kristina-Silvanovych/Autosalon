import { NgModule } from '@angular/core';
import { AuthButtonComponent } from './components/auth.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatToolbarModule} from '@angular/material/toolbar'; 

@NgModule({
    declarations: [
        AuthButtonComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        MatToolbarModule
    ],
    exports: [
        AuthButtonComponent,
        RouterModule
    ],
    providers: []
        
})
export class AuthenticationModule { }
