export interface GameDTO {
    id: number;
    title: string;
    poster: string;
}

export interface LandingPageDTO {
    newlyReleases?: GameDTO[];
    upcomingReleases?: GameDTO[];
}

export interface filterGamesForm {
    title: string;
    genreId: number;
    upcomingReleases: boolean;
    newlyReleases: boolean;
}