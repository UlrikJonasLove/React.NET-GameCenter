import { Field, Form, Formik } from "formik"
import { genreDTO } from "../genres/models/GenreDTOs.model"
import { Button } from "../Utils/Button"
import { filterGamesForm } from "./interface/games.model"

export const FilterGame = () => {
    document.title = "Game Center - Search"

    const initialValue: filterGamesForm = {
        title: "",
        genreId: 0,
        upcomingReleases: false,
        newlyReleases: false
    }

    const genres: genreDTO[] = [{id: 1, name: "Action"}, {id: 2, name: "RPG"}, {id: 3, name: "Fantasy"}]
    return(
        <>
            <h3>Search</h3>
            <Formik initialValues={initialValue}
            onSubmit={values => console.log(values)} 
            >{(formikProps) => (
                <Form>
                    <div className="row gx-3 align-items-center">
                        <div className="col-auto">
                            <input type="text" className="form-control" 
                            id="title" 
                            placeholder="Title of the Game"
                            {...formikProps.getFieldProps("title")}
                            ></input>
                        </div>
                        <div className="col-auto">
                            <select className="form-select"
                            {...formikProps.getFieldProps("genreId")}>
                                <option value="0">
                                    - Choose a Genre - 
                                </option>
                                {genres.map(genre => <option key={genre.id} value={genre.id}>{genre.name}</option>)}
                            </select>
                        </div>
                        <div className="col-auto">
                            <div className="form-check">
                                <Field className="form-check-input" id="upcomingReleases" name="upcomingReleases" type="checkbox"/>
                                <label className="form-check-label" htmlFor="upcomingReleases">Upcoming Releases</label>
                            </div>
                        </div>
                        <div className="col-auto">
                            <div className="form-check">
                                <Field className="form-check-input" id="newlyReleases" name="newlyReleases" type="checkbox"/>
                                <label className="form-check-label" htmlFor="newlyReleases">Newly Releases</label>
                            </div>
                        </div>
                        <div className="col-auto">
                            <Button className="btn btn-primary" onClick={() => formikProps.submitForm()}>Search</Button>
                            <Button className="btn btn-danger ms-3" onClick={() => formikProps.setValues(initialValue)}>Clear</Button>
                        </div>
                    </div>
                </Form>
            )}</Formik>
        </>
    )
}