import { actorGameDto } from "../../actors/model/actorsDTOs.model";

export interface GameDto {
    id: number;
    title: string;
    poster: string;
}

export interface LandingPageDto {
    newlyReleases?: GameDTO[];
    upcomingReleases?: GameDTO[];
}

export interface GameCreationDto {
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

export interface filterGamesFormDto {
    title: string;
    genreId: number;
    upcomingReleases: boolean;
    newlyReleases: boolean;
}