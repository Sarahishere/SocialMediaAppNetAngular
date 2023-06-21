import { Photo } from "./photo"

export interface Member {
    userName: string
    firstName: string
    lastName: string
    photoUrl: string
    age: number
    createDate: Date
    updateDate: Date
    knownAs: string
    lastActive: string
    gender: string
    introduction: string
    lookingFor: string
    interests: string
    city: string
    country: string
    photos: Photo[]
  }
  
