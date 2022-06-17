import { actorGameDto } from "../../actors/model/actorsDTOs.model";
import { genreDTO } from "../../genres/models/Genres.model";
import { gameCenterDTO } from "../../gamecenters/models/GameCenterDTO.model";

export interface GameDto {
    id: number;
    title: string;
    poster: string;
    newlyReleased: boolean;
    trailer: string;
    summary?: string;
    releaseDate: Date;
    genres: genreDTO[];
    gameCenters: numgameCenterDTOber[];
    actors: actorGameDto[];
    userVote: number;
    averageVote: number;
}

export interface LandingPageDto {
    newlyReleased?: GameDTO[];
    upcomingReleases?: GameDTO[];
}

export interface GameCreationDto {
    title: string;
    newlyReleased: boolean;
    trailer: string;
    summary?: string;
    releaseDate?: Date;
    poster?: File;
    posterUrl?: string;
    genreIds?: number[];
    gameCenterIds?: number[];
    actors?: actorGameDto[];
}

export interface filterGamesFormDto {
    title: string;
    genreId: number;
    upcomingReleases: boolean;
    newlyReleased: boolean;
    page: number;
    recordsPerPage: number;
}

export interface gamesPostGetDto {
    genres: genreDTO[];
    gameCenter: gameCenterDTO[];
}

export interface gamePutGetDto {
    game: GameDto;
    selectedGenres: genreDTO[];
    nonSelectedGenres: genreDTO[];
    SelectedGameCenters: gameCenterDTO[];
    nonSelectedGameCenters: gameCenterDTO[];
    actors: actorGameDto[];
}