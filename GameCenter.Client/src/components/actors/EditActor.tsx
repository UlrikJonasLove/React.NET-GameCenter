import { ActorForm } from "./ActorForm";

export const EditActor = () => {
    return(
        <>
            <h3>Edit Actor</h3>
            <ActorForm model={{name: "Ulrik Rosberg", 
            dateOfBirth: new Date("1993-10-22T00:00:00"),
            pictureURL: "some image",
            biography: "Hello"
        }}
            
                onSubmit={values => console.log(values)}
                />
        </>
    )
}