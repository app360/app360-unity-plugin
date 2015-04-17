//
//  NSDictionary+JSON.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/17/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "NSDictionary+JSON.h"

@implementation NSDictionary (JSON)

- (NSString *)toJSONString
{
    NSError *serializationError = nil;
    NSData *jsonData = nil;
    if(self != nil) {
        jsonData = [NSJSONSerialization dataWithJSONObject:self options:0 error:&serializationError];
    }
    
    NSString *jsonString = nil;
    if (jsonData) {
        jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    }
    return jsonString;
}

@end
