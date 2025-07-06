import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms'; 
import { Job } from '../../models/job.model';
import { JobService } from '../../services/job.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-job',
  imports: [RouterModule, CommonModule, FormsModule], 
  templateUrl: './add-job.component.html',
  styleUrls: ['./add-job.component.css'] 
})
export class AddJobComponent {
  job: Job = {
    title: '',
    description: '',
    company: '',
    location: '',
    postedDate: new Date(),
  };

  constructor(private jobService: JobService , private router: Router) {}

  saveJob(): void {
    this.jobService.addJob(this.job).subscribe({
      next: () => {
        this.router.navigate(['/jobs']);
      },
      error: (err) => {
        console.error('Error adding job:', err);
      }

    });

  }


}
