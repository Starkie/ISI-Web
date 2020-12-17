import { Component, OnInit } from "@angular/core";
import { Application } from "../model/Application";
import { Photographer } from "../model/Photographer";
import { ApplicationService } from "./services/application.service";
import { PhotographerService } from "./services/photographer.service";

@Component({
  selector: "app-application",
  templateUrl: "./application.component.html",
  styleUrls: ["./application.component.css"],
})
export class ApplicationComponent implements OnInit {
  constructor(
    private applicationService: ApplicationService,
    private photographerService: PhotographerService
  ) {}

  applications?: Application[];

  photographers?: Photographer[];

  newApplication?: Application;

  cols: any[];

  ngOnInit(): void {
    this.getPhotographers();
    this.getApplications();

    this.newApplication = this.getEmptyApplication();

    this.cols = [
      { field: "id", header: "Id" },
      { field: "photographerId", header: "Photographer", type: "Photographer" },
      { field: "date", header: "Date" },
      { field: "equipmentDescription", header: "Equipment Description" },
      { field: "resume", header: "Resume" },
    ];
  }
  getApplications(): void {
    this.applicationService
      .getApplications()
      .subscribe((as) => (this.applications = as));
  }

  getPhotographers(): void {
    this.photographerService.getPhotographers().subscribe((ps) => {
      this.photographers = ps;
    });
  }

  createApplication(): void {
    if (
      this.newApplication.photographerId == -1 ||
      !this.newApplication.resume.trim() ||
      !this.newApplication.equipmentDescription.trim()
    ) {
      return;
    }

    this.newApplication.date = new Date();

    this.applicationService
      .createApplication(this.newApplication)
      .subscribe((app) => {
        if (!app) {
          return;
        }

        this.newApplication = this.getEmptyApplication();

        this.getApplications();
      });
  }

  getEmptyApplication(): Application {
    return { photographerId: -1 } as Application;
  }
}
