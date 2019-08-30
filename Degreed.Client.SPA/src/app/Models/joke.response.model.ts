export interface JokeResponse {
  id: number;
  joke: string;
  status: number;
  JokeLength: number;
}

export interface ResultJokeModelResponse {
  currentPage: number;
  limit: number;
  nextPage: number;
  previousPage: number;
  results: JokeResponse[];
  searchTerm: string;
  totalJokes: number;
  totalPages: number;
}

enum JokeLengthEnum {
  Short = 10,
  Medium = 20,
  Long = 30
}
