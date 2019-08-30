import { Subscription, interval } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { ApiService } from '../Services/api.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { JokeResponse, ResultJokeModelResponse } from '../Models/joke.response.model';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css'],
  providers: [ApiService]
})
export class ContentComponent implements OnInit {

  joke: JokeResponse;
  formGroup: FormGroup;
  longJokes: JokeResponse[];
  smallJokes: JokeResponse[];
  subscription: Subscription;
  mediumJokes: JokeResponse[];
  jokes: ResultJokeModelResponse;
  hasSearched = false;
  hasResults = false;
  searchedTerm: string;
  constructor(private apiService: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    // Create form
    this.createForm();
    // Set interval for joke fetching
    const source = interval(10000);
    this.getNewJoke();
    this.subscription = source.subscribe(val => this.apiService.getJoke().subscribe((data) => {
      console.log(data);
      this.joke = data;
    }, (error) => {
      console.log(error);
    }));
  }

  // Get new joke from button
  public getNewJoke() {
    this.apiService.getJoke().subscribe((data) => {
      this.joke = data;
    }, (error) => {
      console.log(error);
    });
  }

  createForm() {
    this.formGroup = this.formBuilder.group({
      searchedValue: [null, [Validators.required, Validators.maxLength(30)]]
    });
  }

  // Search jokes by a term
  public searchTerm(searchedTerm: any) {
    this.searchedTerm = searchedTerm.searchedValue;
    this.apiService.seachJokesByTerm(searchedTerm).subscribe((data) => {
      console.log(data);
      this.smallJokes = data.results.filter(item => item.JokeLength === 10);
      this.mediumJokes = data.results.filter(item => item.JokeLength === 20);
      this.longJokes = data.results.filter(item => item.JokeLength === 30);
      this.hasSearched = true;
      this.hasResults = true;
    }, (error) => {
      this.hasResults = false;
      this.hasSearched = true;
    });
  }
}
