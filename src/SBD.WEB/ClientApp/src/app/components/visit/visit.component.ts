import { AuthService } from "../../services/auth.service";
import { Router, ActivatedRoute } from "@angular/router";

export class VisitComponent {

  isLoggedIn: boolean;
  patientId: string;

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) { }
}
