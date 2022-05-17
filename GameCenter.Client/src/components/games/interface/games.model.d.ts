import { actorGameDto } from "../../actors/model/actorsDTOs.model";

export interface GameDTO {
    id: number;
    title: string;
    poster: string;
}

export interface LandingPageDTO {
    newlyReleases?: GameDTO[];
    upcomingReleases?: GameDTO[];
}

export interface GameCreationDTO {
    title: string;
    newlyReleased: boolean;
    trailer: string;
    releaseDate?: Date;
    poster?: File;
    posterUrl?: string;
    genresIds?: number[];
    gameCentersIds?: number[];
    actors?: actorGameDto[];
}

export interface filterGamesForm {
    title: string;
    genreId: number;
    upcomingReleases: boolean;
    newlyReleases: boolean;
}