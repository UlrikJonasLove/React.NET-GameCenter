export interface GameDTO {
    id: number;
    title: string;
    poster: string;
}

export interface LandingPageDTO {
    newlyReleases?: GameDTO[];
    upcomingReleases?: GameDTO[];
}