module Tests.YamlRunner.Skips

type SkipSection = All | Section of string | Sections of string list

type SkipFile = SkipFile of string 

let SkipList = dict [
    // These send empty strings for required parameters
    // TODO i THINK this is now supported
    (SkipFile "ml/explain_data_frame_analytics.yml", Section "Test neither job id nor body")
    (SkipFile "privileges/10_basic.yml ", Section "Test put and delete privileges")
    
    // tries to change current users password, not something we keep track of with later tests
    (SkipFile "change_password/10_basic.yml", Section "Test user changing their own password")
    
    // Test looks for "testnode.crt", but "ca.crt" is returned first
    (SkipFile "ssl/10_basic.yml", Section "Test get SSL certificates")
]


